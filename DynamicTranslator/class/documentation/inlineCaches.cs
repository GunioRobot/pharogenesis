inlineCaches
"
The send opcodes have only one responsibility: finding the translated method corresponding to the receiver and selector.  The appropriate 'invokation response' for this method (including, but not limited to: rejecting the invocation, normal activation, primitive response, special magic to initialise receiver variables from arguments, or whatever) is NOT the responsibility of the send opcode -- but rather that of the translated method's *prologue*.

Each send can therefore optimise its role by 'memoising' its response, without worrying about when the implied assumptions behind this memoisation might become invalid.  The momoisation is accomplished by having two forms of each send opcode, 'unlinked' and 'linked'.  Unlinked sends perform a lookup, then replace themselves with a linked send and memoise the destination method by writing into an extension word at the send site.  Linked sends simply transfer control directly to the prologue of their memoised destination method.  This is the limit of the send opcodes' responsibilities.  An unlinked send opcode looks something like this:

	- initialise messageSelector and argumentCount appropriately;
	- advance localIP to the last extension word, then externalise IP and SP;
	- call #lookupMethodInCache to find the destination method;
	- replace the unlinked send with the corresponding linked send opcode;
	- internalise IP and SP;
	- link to the destination method, and invoke its prologue.

Linking to the destination method involves several steps:

	- write the address of the translated method into the extension word at localIP;
	- choose an appropriate prologue for the method;
	- write the prologue into the translated method header;
	- write any relevant prologue extension word(s) into the translated method header;
	- execute the method prologue.

The method prologue has two distinct reponsibilities, implemented as two distinct 'opcodes' that are dispatched explicitly (rather than implicitly though localIP).

The first responsibility is to check the validity of any assumptions (such as the class of the receiver) that might have been made by the send opcode.  If these assumtions are no longer valid then the prologue must 'fail' the send, normally by relinking it.  Note that the conditions in effect when the prologue executes are precisely those in effect when the send was first linked -- the prologue can therefore fail the send by simply reinvoking the linking procedure described above.  This part of the prologue is implemented by a 'check' opcode.

The choice of check opcode to use is determined by several factors.  These are approximately as follows:

  -	if the receiver is a tagged type then opCheckTag is used.  This fails the send if the
	receiver does not have the expected tag.

  -	if the receiver is an instance of a compact class, opCheckCompact is used.  This relinks
	the send if the receiver's base header does not have the expected compact class index.

  -	otherwise, opCheckClass is used.  This relinks the send if the receiver's class is not the
	same as the method class that is stored in the translated method's header.

Note that the correct choice of check opcode depends on the conditions at the send site at the time the send is linked.  The choice is therefore made in the send linking routine; hence a translated method is initially generated with an illegal check opcode, overwritten with a legal opcode at the time the send is first linked.

If the send succeeds then a second 'activation opcode' is executed.  This secondary opcode is chosen approximately as follows:

  -	if the original CompiledMethod has a primitive index then opActivatePrimitive is used.
	This first tries running the corresponding primitive (whose index is stored in an activation
	extension word) and either continues execution in the caller at localIP (if successFlag is true)
	or activates the translated method normally (if the successFlag is false) to run the primitive
	failure code.

  -	if the original CompiledMethod has no primitive response, opActivate is used to unconditionally
	activate the method.

Other activation responses are possible.  For example, a translated method that contains only:

	[PushTemporaryVariable StoreAndPopReceiverVariable]+ Return

can use a dedicated activation prologue that performs the necessary initialisation of the receiver without ever needing to activate the method.  (Method activation is very expensive compared to the cost of opcode and prologue dispatch.)

Note that the choice of activation opcode depends on the nature of the original CompiledMethod, and is therefore made at method translation time.  Once chosen, the activation opcode is never altered.

Each translated method therefore requires 28 bytes of header, as follows:

	0:	=methodBias					(#translateNewMethod explains what this is for)
	1:	 methodSelector				(used during relink -- the send's selector is no longer available)
	2:	=argumentCount				(needed to pop the stack during activation)
	3:	=prologueOpcode				(e.g: =opCheckTag,	=opCheckCompact,	=opCheckClass	)
	4:	 prologueExtensionWord		(e.g:  nil,			=ccIndex,			 classOoop		)
	5:	=activationOpcode			(e.g: =opActivate,	=opActivatePrimitive					)
	6:	 activationExtensionWord	(e.g:  nil,			=primitiveIndex						)
	7:	... opcodes ...

Note that the default path through the above mechanism (linked send, check succeeds, dispatch to activation) avoids needlessly externalising IP and SP before reaching the activation opcode.  For example, the overheads for a primitive send to a SmallInteger are as follows:

[linked send opcode]
	- increment localIP to point to last extension word
	- load the destination method address from (longAt: localIP)
	- load the prologue check opcode (fetchWord: CheckOpcodeIndex ofObject: newTranslatedMethod)
	- execute it (execOp: checkProlog)
[check opcode]
	- fetch the argument count (fetchInteger: ArgCountIndex ofObject: newTranslatedMethod)
	- tag-check the receiver (isIntegerObject: (internalStackValue: argumentCount))
	- load the activation opcode (fetchWord: ActivationOpcodeIndex ofObject: newTranslatedMethod)
	- execute it (execOp: activationProlog)
[activate opcode]
	- fetch the primitive index (fetchInteger: PrimitiveIndexIndex ofObject: newTranslatedMethod)
	- try the primitive (externaliseIPandSP; primitiveResponse: primIndex)
	- activate on failure (successFlag or: [self activateNewMethod])
	- dispatch next instruction (internaliseIPandSP; self endOp)
[success: opcode following send;  failure: first opcode of fail-case code in activated method]
"
	^self error: 'documentation only'
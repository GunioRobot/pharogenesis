aComment
	"The mark phase is based on a pointer reversing traversal. This is a little tricky because the class, which is needed by the traversal, may be in either the header (as a compact class index) or in the word above the header. See memo 'Revised object format'.
	Compact classes are marked and traced separately.
	How do you know that you are returning from having marked a class? Parent pointer has 10 in low bits.

Here are the states an object may be in, followed by what to do next in brackets []:

  Start Object: parentField is set, [obj _ child]:
	obj is pointed at by a field in parent that is being traced now. obj is marked.
		[(parent goes up to the next field) field addr _ obj. go to Upward]
	obj is pointed at by a field in parent that is being traced now. obj is unmarked. obj has no pointers.
		[put 10 into low bits of header. field addr _ obj. go to Start Field (to process class word)]
	obj is pointed at by a field in parent that is being traced now. obj is unmarked. obj has pointers.
		[put 10 into low bits of header. point to last field. go to Start Field]

  Start Field: 
	Field ends in 10. It is the header. Short Class is not 0.
		[Set low bits to correct value. (have parent pointer) go to Upward]
	Field ends in 10. It is the header. Short Class is 0.
		[child _ word above header. low bits of child _ 01. class word _ parentField. parentField _ loc of class word. go to Start Obj]
	Field is Integer.
		[point one word up, go to Start Field]
	Field is oop.
		[child _ field. field _ parentField. parentField _ loc of field. go to Start Obj]

  Upward [restore low bits of header (at field addr)]:
	parentField is 3. (bits 11, int 1).
		[done!]
	parentField ends in 00.
		[child _ field addr. field addr _ parentField. parentField _ field addr contents.
		field addr contents _ child (addr of prev object. its oop). field addr - 4. go to Start Field]
	parentField ends in 01. Were tracing the class.
		[child _ field addr. field addr _ parentField (loc of class word). parentField _ field addr contents.
		field addr contents _ child (addr of prev object. its oop). field addr + 4 (header). go to Upward]
"
primPCRECompile

"<rcvr primPCRECompile>, where rcvr is an object with instance variables:

	'patternStr compileFlags pcrePtr extraPtr errorStr errorOffset matchFlags'	

Compile the regular expression in patternStr, and if the compilation is successful, attempt to optimize the compiled expression.  Store the results in <pcrePtr> and <extratr>, or fill errorStr with a meaningful errorString and errorOffset with an indicator where the error was found, applying compileFlags throughout.  Answer nil with a clean compile (regardless of whether an optimization is possible, and answer with the string otherwise."


	self export: true.
	self loadRcvrFromStackAt: 0.
	patternStrPtr _ self rcvrPatternStrPtr.
	compileFlags _ self rcvrCompileFlags.
	interpreterProxy failed ifTrue:[^ nil].

	pcrePtr _ self cCode: '(int) pcre_compile(patternStrPtr, compileFlags, 
					&errorStrBuffer, &errorOffset, NULL)'.
	pcrePtr
		ifTrue: [
			self allocateByteArrayAndSetRcvrPCREPtrFromPCRE: pcrePtr.
			extraPtr _ self cCode: '(int) pcre_study((pcre *)pcrePtr, compileFlags, &errorStrBuffer)'.
			self allocateByteArrayAndSetRcvrExtraPtrFrom: extraPtr.
			self rePluginFree: (self cCoerce: pcrePtr to: 'void *').
			extraPtr ifTrue: [self rePluginFree: (self cCoerce: extraPtr to: 'void *')].
			interpreterProxy failed ifTrue:[^ nil].
			interpreterProxy pop: 1 thenPush: interpreterProxy nilObject]
		ifFalse: [
			errorStr _ self allocateStringAndSetRcvrErrorStrFromCStr: errorStrBuffer.
			self rcvrErrorOffsetFrom: errorOffset.
			interpreterProxy failed ifTrue:[^ nil].
			interpreterProxy pop: 1 thenPush: errorStr].
setStandardClass: aClass methodSymbol: methodSym

	classSymbol _ aClass theNonMetaClass name.
	classIsMeta _ aClass isMeta.
	methodSymbol _ methodSym.
	stringVersion _ aClass name , ' ' , methodSym.
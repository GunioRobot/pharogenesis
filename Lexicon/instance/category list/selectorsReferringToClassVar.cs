selectorsReferringToClassVar
	"Return a list of methods that refer to given class var that are in the 
	protocol of this object"
	| aList aClass nonMeta poolAssoc |
	nonMeta _ targetClass theNonMetaClass.
	aClass _ nonMeta classThatDefinesClassVariable: currentQueryParameter.
	aList _ OrderedCollection new.
	poolAssoc _ aClass classPool associationAt: currentQueryParameter asSymbol.
	(self systemNavigation allCallsOn: poolAssoc)
		do: [:elem | (nonMeta isKindOf: elem actualClass)
				ifTrue: [aList add: elem methodSymbol]].
	^ aList
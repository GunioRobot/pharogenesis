writeMultiFieldColor: fields on: aVRMLStream indent: level 
	"This method was automatically generated"
	aVRMLStream nextPut: $[.
	1 to: fields size do:[:i|
		i > 1 ifTrue:[aVRMLStream crtab: level+1].
		self storeSingleFieldColor: (fields at: i) on: aVRMLStream indent: level+1].
	aVRMLStream nextPut:$].
computeImageSegmentation
	"Smalltalk computeImageSegmentation"
	"Here's how the segmentation works:
	For each partition, we collect the classes involved, and also all
	messages no longer used in the absence of this partition. We
	start by computing a 'Miscellaneous' segment of all the
	unused classes in the system as is."
	| partitions unusedCandM newClasses expandedCandM |
	partitions := Dictionary new.
	unusedCandM := self unusedClassesAndMethodsWithout: {{}. {}}.
	partitions at: 'Miscellaneous' put: unusedCandM.
	newClasses := Array
				streamContents: [:s | (SystemOrganization categoriesMatching: 'VMConstruction-*')
						do: [:cat | (SystemOrganization superclassOrder: cat)
								do: [:c | s nextPut: c name]]].
	expandedCandM := self unusedClassesAndMethodsWithout: {unusedCandM first asArray , newClasses. unusedCandM second}.
	partitions at: 'VMConstruction' put: {(expandedCandM first copyWithoutAll: unusedCandM first) addAll: newClasses;
			 yourself. expandedCandM second copyWithoutAll: unusedCandM second}.
	unusedCandM := expandedCandM.
	newClasses := Array
				streamContents: [:s | (SystemOrganization categoriesMatching: 'ST80-*')
						do: [:cat | (SystemOrganization superclassOrder: cat)
								do: [:c | s nextPut: c name]]].
	expandedCandM := self unusedClassesAndMethodsWithout: {unusedCandM first asArray , newClasses. unusedCandM second}.
	partitions at: 'ST80' put: {(expandedCandM first copyWithoutAll: unusedCandM first) addAll: newClasses;
			 yourself. expandedCandM second copyWithoutAll: unusedCandM second}.
	unusedCandM := expandedCandM.
	newClasses := Array
				streamContents: [:s | (SystemOrganization categoriesMatching: 'Morphic-Games')
						do: [:cat | (SystemOrganization superclassOrder: cat)
								do: [:c | s nextPut: c name]]].
	expandedCandM := self unusedClassesAndMethodsWithout: {unusedCandM first asArray , newClasses. unusedCandM second}.
	partitions at: 'Games' put: {(expandedCandM first copyWithoutAll: unusedCandM first) addAll: newClasses;
			 yourself. expandedCandM second copyWithoutAll: unusedCandM second}.
	unusedCandM := expandedCandM.
	newClasses := Array
				streamContents: [:s | (SystemOrganization categoriesMatching: 'Morphic-Remote')
						do: [:cat | (SystemOrganization superclassOrder: cat)
								do: [:c | s nextPut: c name]]].
	expandedCandM := self unusedClassesAndMethodsWithout: {unusedCandM first asArray , newClasses. unusedCandM second}.
	partitions at: 'Nebraska' put: {(expandedCandM first copyWithoutAll: unusedCandM first) addAll: newClasses;
			 yourself. expandedCandM second copyWithoutAll: unusedCandM second}.
	unusedCandM := expandedCandM.
	newClasses := Array
				streamContents: [:s | ((SystemOrganization categoriesMatching: 'Network-*')
						copyWithoutAll: #('Network-Kernel' 'Network-Url' 'Network-Protocols' 'Network-ObjectSocket' ))
						do: [:cat | (SystemOrganization superclassOrder: cat)
								do: [:c | s nextPut: c name]]].
	expandedCandM := Smalltalk unusedClassesAndMethodsWithout: {unusedCandM first asArray , newClasses. unusedCandM second}.
	partitions at: 'Network' put: {(expandedCandM first copyWithoutAll: unusedCandM first) addAll: newClasses;
			 yourself. expandedCandM second copyWithoutAll: unusedCandM second}.
	unusedCandM := expandedCandM.
	newClasses := Array
				streamContents: [:s | (SystemOrganization categoriesMatching: 'Balloon3D-*')
						do: [:cat | (SystemOrganization superclassOrder: cat)
								do: [:c | s nextPut: c name]]].
	expandedCandM := self unusedClassesAndMethodsWithout: {unusedCandM first asArray , newClasses. unusedCandM second}.
	partitions at: 'Balloon3D' put: {(expandedCandM first copyWithoutAll: unusedCandM first) addAll: newClasses;
			 yourself. expandedCandM second copyWithoutAll: unusedCandM second}.
	unusedCandM := expandedCandM.
	newClasses := Array
				streamContents: [:s | (SystemOrganization categoriesMatching: 'FFI-*')
						do: [:cat | (SystemOrganization superclassOrder: cat)
								do: [:c | s nextPut: c name]]].
	expandedCandM := self unusedClassesAndMethodsWithout: {unusedCandM first asArray , newClasses. unusedCandM second}.
	partitions at: 'FFI' put: {(expandedCandM first copyWithoutAll: unusedCandM first) addAll: newClasses;
			 yourself. expandedCandM second copyWithoutAll: unusedCandM second}.
	unusedCandM := expandedCandM.
	newClasses := Array
				streamContents: [:s | (SystemOrganization categoriesMatching: 'Genie-*')
						do: [:cat | (SystemOrganization superclassOrder: cat)
								do: [:c | s nextPut: c name]]].
	expandedCandM := self unusedClassesAndMethodsWithout: {unusedCandM first asArray , newClasses. unusedCandM second}.
	partitions at: 'Genie' put: {(expandedCandM first copyWithoutAll: unusedCandM first) addAll: newClasses;
			 yourself. expandedCandM second copyWithoutAll: unusedCandM second}.
	unusedCandM := expandedCandM.
	newClasses := Array
				streamContents: [:s | (SystemOrganization categoriesMatching: 'Speech-*')
						do: [:cat | (SystemOrganization superclassOrder: cat)
								do: [:c | s nextPut: c name]]].
	expandedCandM := self unusedClassesAndMethodsWithout: {unusedCandM first asArray , newClasses. unusedCandM second}.
	partitions at: 'Speech' put: {(expandedCandM first copyWithoutAll: unusedCandM first) addAll: newClasses;
			 yourself. expandedCandM second copyWithoutAll: unusedCandM second}.
	unusedCandM := expandedCandM.
	newClasses := Array
				streamContents: [:s | #('Morphic-Components' )
						do: [:cat | (SystemOrganization superclassOrder: cat)
								do: [:c | s nextPut: c name]]].
	expandedCandM := Smalltalk unusedClassesAndMethodsWithout: {unusedCandM first asArray , newClasses. unusedCandM second}.
	partitions at: 'Components' put: {(expandedCandM first copyWithoutAll: unusedCandM first) addAll: newClasses;
			 yourself. expandedCandM second copyWithoutAll: unusedCandM second}.
	unusedCandM := expandedCandM.
	newClasses := Array
				streamContents: [:s | #('Sound-Scores' 'Sound-Interface' )
						do: [:cat | (SystemOrganization superclassOrder: cat)
								do: [:c | s nextPut: c name]]].
	newClasses := newClasses , #(#WaveletCodec #Sonogram #FWT #AIFFFileReader ).
	expandedCandM := self unusedClassesAndMethodsWithout: {unusedCandM first asArray , newClasses. unusedCandM second}.
	partitions at: 'Sound' put: {(expandedCandM first copyWithoutAll: unusedCandM first) addAll: newClasses;
			 yourself. expandedCandM second copyWithoutAll: unusedCandM second}.
	unusedCandM := expandedCandM.
	newClasses := Array
				streamContents: [:s | ((SystemOrganization categoriesMatching: 'Tools-*')
						copyWithout: 'Tools-Menus')
						do: [:cat | (SystemOrganization superclassOrder: cat)
								do: [:c | s nextPut: c name]]].
	newClasses := newClasses copyWithoutAll: #(#Debugger #Inspector #ContextVariablesInspector #SyntaxError #ChangeSet #ChangeRecord #ClassChangeRecord #ChangeList #VersionsBrowser ).
	expandedCandM := self unusedClassesAndMethodsWithout: {unusedCandM first asArray , newClasses. unusedCandM second}.
	partitions at: 'Tools' put: {(expandedCandM first copyWithoutAll: unusedCandM first) addAll: newClasses;
			 yourself. expandedCandM second copyWithoutAll: unusedCandM second}.
	unusedCandM := expandedCandM.
	newClasses := Array
				streamContents: [:s | (SystemOrganization categoriesMatching: 'Balloon-MMFlash*')
						do: [:cat | (SystemOrganization superclassOrder: cat)
								do: [:c | s nextPut: c name]]].
	newClasses := newClasses , #(#ADPCMCodec ).
	expandedCandM := self unusedClassesAndMethodsWithout: {unusedCandM first asArray , newClasses. unusedCandM second}.
	partitions at: 'Flash' put: {(expandedCandM first copyWithoutAll: unusedCandM first) addAll: newClasses;
			 yourself. expandedCandM second copyWithoutAll: unusedCandM second}.
	unusedCandM := expandedCandM.
	newClasses := Array
				streamContents: [:s | (SystemOrganization categoriesMatching: 'Balloon-TrueType*')
						do: [:cat | (SystemOrganization superclassOrder: cat)
								do: [:c | s nextPut: c name]]].
	expandedCandM := self unusedClassesAndMethodsWithout: {unusedCandM first asArray , newClasses. unusedCandM second}.
	partitions at: 'TrueType' put: {(expandedCandM first copyWithoutAll: unusedCandM first) addAll: newClasses;
			 yourself. expandedCandM second copyWithoutAll: unusedCandM second}.
	unusedCandM := expandedCandM.
	newClasses := Array
				streamContents: [:s | (SystemOrganization categoriesMatching: 'Graphics-Files')
						do: [:cat | (SystemOrganization superclassOrder: cat)
								do: [:c | s nextPut: c name]]].
	expandedCandM := self unusedClassesAndMethodsWithout: {unusedCandM first asArray , newClasses. unusedCandM second}.
	partitions at: 'GraphicFiles' put: {(expandedCandM first copyWithoutAll: unusedCandM first) addAll: newClasses;
			 yourself. expandedCandM second copyWithoutAll: unusedCandM second}.
	unusedCandM := expandedCandM.
	#(#AliceConstants 'Balloon3D' #B3DEngineConstants 'Balloon3D' #WonderlandConstants 'Balloon3D' #FFIConstants 'FFI' #KlattResonatorIndices 'Speech' )
		pairsDo: [:poolName :part | (partitions at: part) first add: poolName].
	partitions
		keysDo: [:k | k = 'Miscellaneous'
				ifFalse: [(partitions at: 'Miscellaneous') first removeAllFoundIn: (partitions at: k) first]].
	^ partitions
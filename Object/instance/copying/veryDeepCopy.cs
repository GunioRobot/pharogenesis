veryDeepCopy
	"Do a complete tree copy using a dictionary.  An object in the tree twice is only copied once.  Both pointers point to one new copy.  Uses ReferenceStream.  To see where the copying stops, see DataStream.typeIDFor: and implementors of objectToStoreOnDataStream"

	| dummy refs class index sub val hashers new |
	self allMorphsDo: [:m | m prepareToBeSaved].		"Actors fix open scriptEditors"
	dummy _ ReferenceStream on: (DummyStream on: nil).
		"Write to a fake Stream, not a file"
	"Collect all objects"
	dummy rootObject: self.	"inform him about the root"
	dummy nextPut: self.	"Do the traverse of the tree"
	refs _ dummy references.	"all the objects"
	"For each object, make a simple copy, then replace all fields with new copy from dict"
	refs keysDo: [:each | refs at: each put: each shallowCopy].
		"Watch out for classes that do extra things in copy but not in shallowCopy"
	hashers _ OrderedCollection new.
	refs associationsDo: [:assoc | 
		assoc key == assoc value ifFalse: ["is a new object"
			new _ assoc value.
			class _ new class.
			class isVariable
				ifTrue: 
					[index _ new basicSize.
					[index > 0] whileTrue: 
						[sub _ new basicAt: index.
						(val _ refs at: sub ifAbsent: [nil]) ifNotNil: [
								"If not in refs, then the right value is already in the field"
								new basicAt: index put: val].
						index _ index - 1]].
			index _ class instSize.
			[index > 0] whileTrue: 
				[sub _ new instVarAt: index.
				(val _ refs at: sub ifAbsent: [nil]) ifNotNil: [
						"If not in refs, then the right value is already in the field"
						new instVarAt: index put: val].
				index _ index - 1].
			(new respondsTo: #rehash) ifTrue: [hashers add: new].
			]].
	"Force new sets and dictionaries to rehash"
	hashers do: [:each | each rehash].

	^ refs at: self
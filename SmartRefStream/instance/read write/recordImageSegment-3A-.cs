recordImageSegment: refs
	"Besides the objects being written out, record the structure of instances inside the image segment we are writing out."

	| cls list |
	refs keysDo: [:each | 
		cls _ each class.
		cls isObsolete ifTrue: [self error: 'Trying to write ', cls name].
		cls class == Metaclass 
			ifFalse: [structures at: cls name put: false.
				(each isKindOf: ImageSegment) ifTrue: [
					each outPointers do: [:out |
						(out isKindOf: Class) ifTrue: [
							structures at: out theNonMetaClass name put: false]]]]
		].
	list _ refs at: #BlockReceiverClasses ifAbsent: [^ self].
	list do: [:meta | structures at: meta name put: false].
		"Just the metaclasses whose instances are block receivers.  Otherwise metaclasses are not allowed."
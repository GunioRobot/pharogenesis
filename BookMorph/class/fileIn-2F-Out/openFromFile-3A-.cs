openFromFile: fullName
	"Reconstitute a Morph from the selected file, presumed to be represent
	a Morph saved via the SmartRefStream mechanism, and open it in an
	appropriate Morphic world"

	| book aFileStream |
	Smalltalk verifyMorphicAvailability ifFalse: [^ self].

	aFileStream _ FileStream oldFileNamed: fullName.
	book _ BookMorph new.
	book setProperty: #url toValue: aFileStream url.
	book fromRemoteStream: aFileStream.
	aFileStream close.

	Smalltalk isMorphic 
		ifTrue: [ActiveWorld addMorphsAndModel: book]
		ifFalse:
			[book isMorph ifFalse: [^self inform: 'Can only load a single morph
into an mvc project via this mechanism.'].
			book openInWorld].
	book goToPage: 1
lookupMethodInDictionary: dictionary
	"This method lookup tolerates integers as Dictionary keys to support
	execution of images in which Symbols have been compacted out"
 	| length index mask wrapAround nextSelector methodArray |
	self inline: true.
	length _ self fetchWordLengthOf: dictionary.
	mask _ length - SelectorStart - 1.
	(self isIntegerObject: messageSelector)
		ifTrue:
		[index _ (mask bitAnd: (self integerValueOf: messageSelector)) + SelectorStart]
		ifFalse:
		[index _ (mask bitAnd: (self hashBitsOf: messageSelector)) + SelectorStart].
	"It is assumed that there are some nils in this dictionary, and search will
	stop when one is encountered.  However, if there are no nils, then wrapAround
	will be detected the second time the loop gets to the end of the table."
	wrapAround _ false.
	[true] whileTrue:
		[nextSelector _ self fetchPointer: index
					ofObject: dictionary.
		nextSelector=nilObj ifTrue: [^false].
		nextSelector=messageSelector
			ifTrue: [methodArray _ self fetchPointer: MethodArrayIndex
							ofObject: dictionary.
				newMethod _ self fetchPointer:  index - SelectorStart
							ofObject: methodArray.
				primitiveIndex _ self primitiveIndexOf: newMethod.
				^true].
		index _ index + 1.
		index = length
			ifTrue: [wrapAround ifTrue: [^false].
				wrapAround _ true.
				index _ SelectorStart]]
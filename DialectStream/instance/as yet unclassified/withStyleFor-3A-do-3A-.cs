withStyleFor: elementType do: aBlock

	"For each element type, associate a color and emphasis"
	elementType == #temporaryVariable ifTrue:
		[^ self withColor: #black emphasis: #normal do: aBlock].
	elementType == #methodArgument ifTrue:
		[^ self withColor: #black emphasis: #normal do: aBlock].
	elementType == #methodSelector ifTrue:
		[^ self withColor: #black emphasis: #bold do: aBlock].
	elementType == #blockArgument ifTrue:
		[^ self withColor: #black emphasis: #normal do: aBlock].
	elementType == #comment ifTrue:
		[^ self withColor: #brown emphasis: #normal do: aBlock].
	elementType == #variable ifTrue:
		[^ self withColor: #black emphasis: #normal do: aBlock].
	elementType == #literal	 ifTrue:
		[^ self withColor: #blue emphasis: #normal do: aBlock].
	elementType == #keyword ifTrue:
		[^ self withColor: #darkGray emphasis: #bold do: aBlock].
	elementType == #prefixKeyword ifTrue:
		[^ self withColor: #veryDarkGray emphasis: #bold do: aBlock].
	elementType == #setOrReturn ifTrue:
		[^ self withColor: #black emphasis: #bold do: aBlock].
	^ self withColor: #black emphasis: #normal do: aBlock
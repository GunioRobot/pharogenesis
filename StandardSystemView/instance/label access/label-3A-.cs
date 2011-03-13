label: aString 
	"Set aString to be the receiver's label."

	aString == nil
		ifTrue:
			[labelText _ nil.
			labelFrame region: (0 @ 0 extent: 0 @ 0)]
		ifFalse:
			[labelText _ (Text string: aString emphasis: "11"8) asParagraph.
			insetDisplayBox == nil ifTrue: [^ self].  "wait for further initialization"
			self setLabelRegion]
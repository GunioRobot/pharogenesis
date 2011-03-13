at: aKey ifAbsent: aBlock
	"Answer the property value associated with aKey or, if aKey isn't found, answer the result of evaluating aBlock."
	
	properties isNil ifTrue: [ ^ aBlock value ].
	^ properties at: aKey ifAbsent: aBlock.
propertyValueAt: aKey ifAbsent: aBlock
	"Answer the property value associated with aKey or, if aKey isn't found, answer the result of evaluating aBlock."
	^self at: aKey ifAbsent: aBlock
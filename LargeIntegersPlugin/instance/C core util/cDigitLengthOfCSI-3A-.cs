cDigitLengthOfCSI: csi 
	"Answer the number of indexable fields of a CSmallInteger. This value is 
	   the same as the largest legal subscript."
	self returnTypeC: 'int'.
	self var: #csi declareC: 'int csi'.
	(csi < 256 and: [csi > -256])
		ifTrue: [^ 1].
	(csi < 65536 and: [csi > -65536])
		ifTrue: [^ 2].
	(csi < 16777216 and: [csi > -16777216])
		ifTrue: [^ 3].
	^ 4
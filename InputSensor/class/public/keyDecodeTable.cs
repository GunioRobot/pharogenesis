keyDecodeTable
	^KeyDecodeTable ifNil: [ self installKeyDecodeTable ]
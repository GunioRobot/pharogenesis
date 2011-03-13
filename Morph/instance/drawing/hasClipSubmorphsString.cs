hasClipSubmorphsString
	^self clipSubmorphs
		ifTrue:['<on>clip submorphs']
		ifFalse:['<off>clip submorphs']
metaclasses
	^self classNames collect: [:ea | (environment at: ea) asClassSideNode]
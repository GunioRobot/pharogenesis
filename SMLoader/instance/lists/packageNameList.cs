packageNameList
	^self packageWrapperList collect: [:e | e withoutListWrapper name]
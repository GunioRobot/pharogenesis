tabsNotToStore
	"Answer a list of quadruplets describing tabs which are not to be stored in the save-file, because they will be supplied by the code as part of the load-save-file mechanism.  Refer to the comment in #scaffoldingTabInfo for the format. "

	^ self scaffoldingTabInfo
		select:
			[:quad | quad fourth == #dontStoreOnFile]
generalOptions
	^#(#('help' #help) 
		#('update map from the net' loadUpdates)
		#('upgrade all installed packages' upgradeInstalledPackagesNoConfirm)
		#('upgrade all installed packages confirming each' upgradeInstalledPackagesConfirm)
		#('put list in paste buffer' listInPasteBuffer)
		#('save filters as default' saveFiltersAsDefault)
		#- )


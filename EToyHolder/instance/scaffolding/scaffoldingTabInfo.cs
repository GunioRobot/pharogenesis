scaffoldingTabInfo
	"Answer an array of quadruplets, with each quadruplet telling:
		(1)	The tab title (with trailing blanks as needed for for spacing)
 		(2)  The dominant color for the tab and its pages
         (3)  The selector to call to get default contents from the EToyHolder
	Individual EToyHolder subclasses can change this list
		(4)  If #storeOnFile, then the contents should go out on the save file
			If #dontStoreOnFile, then the contents are NOT stored on the save file, but
				are instead supplied by the EToyHolder after the save-file is loaded"
	^ #(  
		('Toy   '		blue		scaffoldingToyStrings		storeOnFile)
		('Mail   ' 		brown		scaffoldingMailStrings		dontStoreOnFile)
		('Squeak   '		cyan		scaffoldingSqueakStrings	dontStoreOnFile)
		('Imagis'		magenta	scaffoldingImagineersStrings dontStoreOnFile))
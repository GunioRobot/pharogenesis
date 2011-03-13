updateFrom7002
	"self new updateFrom7002"
	"
	Change Set:		decorateFix-bf
	Date:			24 February 2006
	Author:			Bert Freudenberg

	Bullet-proof browser against removed class
	---------
	0001913: Make all implementors of #nextPut: to return the argument (instead of self)
	Changed some implementors of #nextPut: to return the argument (and not return self). 
	This to be consistent with primitiveNextPut and all other implementors of #nextPut:
	kwl: As dicusses with Ken and Craig on #squeak IRC.
	--------
	0001733: [ENH][FIX] String-upToDep-huma
	Really deprecates SequenceableCollection>>#upTo: to #copyUpTo:
	--------
	PlusTools do not register in Filelist when not active
	-------
	0003049: fast window resizing needed
	0001596: [BUG][FIX] lurking signals in EventSensor
	-------
	- PolygonMorph.st from Connectors
	- cleanups for preference removal
	
	"
	self script41.
	self flushCaches.
	Preferences removePreference: #allowCelesteTell.
	Preferences removePreference: #useFileList2.
	Preferences removePreference: #enableInternetConfig.
	Preferences removePreference: #browserNagIfNoClassComment.
	Preferences removePreference: #alternativeWindowLook.
	Preferences removePreference: #alternativeScrollbarLook.
	Preferences removePreference: #inboardScrollbars.
	Preferences removePreference: #fastSplitterResize.
	FileList initialize.

checkVersion
	"This is Squeak 2.2.  Make sure that the Server:swiki folder is the version for 2.2."

	| fName |
	fName _ ServerAction serverDirectory, 'swiki', (ServerAction pathSeparator), 
				'page.html'.
	(FileDirectory new fileExists: fName) ifFalse: [self inform: 'The path to the Server folder is wrong.
Please modify the following method ...'. 
	Browser openMessageBrowserForClass: ServerAction class 
		selector: #serverDirectory editString: nil.
	^ false].

	fName _ ServerAction serverDirectory, 'swiki', (ServerAction pathSeparator), 
				'render.html'.
	(FileDirectory new fileExists: fName) ifFalse: [self inform: 'Initialization failed.  ''swiki'' folder is out of date.
Get one from:
http://guzdial.cc.gatech.edu/st/Swiki-GuzPWS2.tar or
http://guzdial.cc.gatech.edu/st/Swiki-GuzPWS2.sea'. ^ false].
	^ true

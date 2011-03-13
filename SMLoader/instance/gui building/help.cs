help
	"Present help text. If there is a web server available, offer to open it.
	Use the WebBrowser registry if possible, or Scamper if available."
	| message browserClass |
	message := 'Welcome to the SqueakMap package loader. 
The names of packages are followed by (installed version -> latest version). 
If there is no arrow, your installed version of the package is the latest.
The checkbox menu items at the bottom let you modify which packages 
you''ll see. Take a look at them - only some packages are shown initially. 
The options available for a package depend on how it was packaged. 
If you like a package or have comments on it, please contact
the author or the squeak mailing list.'.

	browserClass := Smalltalk at: #WebBrowser ifPresent: [ :registry | registry default ].
	browserClass := browserClass ifNil: [ Smalltalk at: #Scamper ifAbsent: [ ^self inform: message ]].

	(self confirm: message, '
Would you like to view more detailed help on the SqueakMap swiki page?') 
	ifTrue: [ browserClass openOnUrl: 'http://minnow.cc.gatech.edu/squeak/2726' asUrl]
downloadFonts
	"BDFFontReader downloadFonts"
	"Download a standard set of BDF sources from x.org.  
	The combined size of these source files is around 1.2M; after conversion 
	to .sf2 format they may be deleted."
	| heads tails filenames baseUrl basePath |
	heads := #(
		'charR'
		'courR'
		'helvR'
		'lubR'
		'luRS'
		'lutRS'
		'ncenR'
		'timR'
	).
	tails := #('08' '10' '12' '14' '18' '24' ).
	filenames := OrderedCollection new.
	heads do: [ :head | filenames addAll: (tails collect: [ :tail | head , tail , '.bdf' ]) ].
	baseUrl := Url absoluteFromText: 'http://ftp.x.org/pub/R6.4/xc/fonts/bdf/75dpi/'.
	basePath := baseUrl path.
	filenames do: 
		[ :filename | | newUrl newPath document f |
		newUrl := baseUrl clone.
		newPath := OrderedCollection newFrom: basePath.
		newPath addLast: filename.
		newUrl path: newPath.
		UIManager default 
			informUser: 'Fetching ' translated, filename
			during: [ document := newUrl retrieveContents ].
		f := (MultiByteFileStream newFileNamed: filename)
			ascii; wantsLineEndConversion: true; yourself.
		f nextPutAll: document content.
		f close ]
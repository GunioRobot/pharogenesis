downloadFonts  "BDFFontReader downloadFonts"
	"Download a standard set of BDF sources from x.org.  
	The combined size of these source files is around 1.2M; after conversion 
	to .sf2 format they may be deleted."

	| heads tails filenames baseUrl basePath newUrl newPath document f |
	heads _ #( 'charR' 'courR' 'helvR' 'lubR' 'luRS' 'lutRS' 'ncenR' 'timR' ).
	tails _ #( '08' '10' '12' '14' '18' '24').

	filenames _ OrderedCollection new.
	heads do: [:head |
		filenames addAll: (tails collect: [:tail | head , tail , '.bdf'])
	].

	baseUrl _ Url absoluteFromText: 'http://ftp.x.org/pub/R6.4/xc/fonts/bdf/75dpi/'.
	basePath _ baseUrl path.

	filenames do: [:filename |
		newUrl _ baseUrl clone.
		newPath _ OrderedCollection newFrom: basePath.

		newPath addLast: filename.
		newUrl path: newPath.

		Utilities informUser: 'Fetching ' , filename during: 
			[document _ newUrl retrieveContents].

		f _ CrLfFileStream newFileNamed: filename.
		f nextPutAll: document content.
		f close.
	].

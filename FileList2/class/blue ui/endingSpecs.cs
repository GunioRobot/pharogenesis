endingSpecs
	"Answer a collection of specs to build the selective 'find anything' tool called by the Navigator. This version uses the services registry to do so."
	"FileList2 morphicViewGeneralLoaderInWorld: World"
	| categories services specs rejects |
	rejects _ #(addFileToNewZip: compressFile: openInZipViewer: extractAllFrom: openOn:).
	categories _ #(
		('Art' ('bmp' 'gif' 'jpg' 'jpeg' 'form' 'png' 'pcx' 'xbm' 'xpm' 'ppm' 'pbm'))
		('Morphs' ('morph' 'morphs' 'sp'))
		('Projects' ('extseg' 'project' 'pr'))
		('Books' ('bo'))
		('Music' ('mid'))
		('Movies' ('movie' 'mpg' 'mpeg' 'qt' 'mov'))
		"('Code' ('st' 'cs'))"
		('Flash' ('swf'))
		('TrueType' ('ttf'))
		('3ds' ('3ds'))
		('Tape' ('tape'))
		('Wonderland' ('wrl'))
		('HTML' ('htm' 'html'))
	).
	categories first at: 2 put: ImageReadWriter allTypicalFileExtensions.
	specs _ OrderedCollection new.
	categories do: [ :cat | | catSpecs catServices okExtensions |
		services _ Dictionary new.
		catSpecs _ Array new: 3.
		catServices _ OrderedCollection new.
		okExtensions _ Set new.

		cat second do: [ :ext | (FileList itemsForFile: 'fred.',ext) do: [ :i |
			(rejects includes: i selector) ifFalse: [
				okExtensions add: ext.
				services at: i label put: i ]]].
		services do: [ :svc | catServices add: svc ].
		services isEmpty ifFalse: [ 
			catSpecs at: 1 put: cat first translated;
				at: 2 put: okExtensions;
				at: 3 put: catServices.
			specs add: catSpecs ]
	].
	^specs

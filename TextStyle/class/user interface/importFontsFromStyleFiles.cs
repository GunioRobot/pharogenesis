importFontsFromStyleFiles
	"Import any and all of the fonts found in the default directory in files named ComicBold.style, ComicPlain.style, NewYork.style, Palatino.style, Courier.style"

	| aName |
	#('ComicBold' 'ComicPlain' 'NewYork' 'Palatino' 'Courier') do:
		[:frag |
			(TextStyle knownTextStyles includes: frag) ifFalse:
				[(FileDirectory default fileExists: (aName _ frag, '.style'))
						ifTrue:
							[TextStyle default collectionFromFileNamed: aName]]].
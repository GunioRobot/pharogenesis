viewImageImports
	| imageImports |
	"Open up a special Form inspector on the dictionary of graphical imports."

	(imageImports _ self imageImports) size == 0 ifTrue:
		[^ self inform: 
'The ImageImports repository is currently empty,
so there is nothing to view at this time.  You can
use a file list to import graphics from external files
into ImageImports, and once you have done that,
you will find this command more interesting.'].

	imageImports inspectFormsWithLabel: 'Graphical Imports'
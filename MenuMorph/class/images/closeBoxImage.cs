closeBoxImage
	"Supplied here because we don't necessarily have ComicBold"

	^ CloseBoxImage ifNil: [CloseBoxImage _ (Form
	extent: 10@16
	depth: 2
	fromArray: #( 0 0 0 0 1342259200 1409630208 353697792 89391104 22020096 89391104 353697792 1409630208 1342259200 0 0 0)
	offset: 0@0)]
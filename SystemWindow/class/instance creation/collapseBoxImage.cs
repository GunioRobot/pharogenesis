collapseBoxImage
	"Supplied here because we don't necessarily have ComicBold"

	^ CollapseBoxImage ifNil: [ CollapseBoxImage _ (Form
	extent: 10@10
	depth: 16
	fromArray: #( 0 131074 131074 131074 0 2 131074 131074 131074 131072 131074 131072 0 2 131074 131074 0 0 0 131074 131074 0 0 0 131074 131074 0 0 0 131074 131074 0 0 0 131074 131074 131072 0 2 131074 2 131074 131074 131074 131072 0 131074 131074 131074 0)
	offset: 0@0)]
renderOn: aRenderer
	"Tell the Scene's children to draw themselves"
	"Note: For correct picking, it is important to use B3DRenderEngine>>render: here."
	myChildren do: [:child | aRenderer render: child ].

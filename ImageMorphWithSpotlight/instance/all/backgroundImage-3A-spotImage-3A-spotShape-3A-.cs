backgroundImage: bkgndImage spotImage: anImage spotShape: formOfDepth1

	"See class comment."
	spotImage _ anImage.
	spotShape _ formOfDepth1.
	spotBuffer _ Form extent: spotShape extent depth: spotImage depth.
	super image: bkgndImage.
	spotOn _ false.
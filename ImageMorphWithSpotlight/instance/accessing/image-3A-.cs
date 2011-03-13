image: anImage

	"The spotlight will reveal the original  form supplied
	while the background form will be derived grayscale."
	"See class comment."
	self backgroundImage: anImage asGrayScale
		spotImage: anImage
		spotShape: (Form dotOfSize: 100)

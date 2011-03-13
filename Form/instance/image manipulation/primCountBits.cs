primCountBits
	"Count the non-zero pixels of this form."
	^ (BitBlt toForm: self)
		fillColor: (Bitmap with: 0);
		destRect: (0@0 extent: width@height);
		combinationRule: 22;
		copyBits
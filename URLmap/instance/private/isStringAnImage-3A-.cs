isStringAnImage: anUpperCasedString
	"check the string to see if it end with something that makes it likely to be an image URL"
	^(anUpperCasedString endsWith: '.GIF') or:
		[(anUpperCasedString endsWith: '.JPEG') or:
		[anUpperCasedString endsWith: '.JPG']]
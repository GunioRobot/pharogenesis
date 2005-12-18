temps: anArray
	"Store the arguments as the temporary variables"

	anArray
		withIndexDo:[:each :index | self tempAt: index put: each]

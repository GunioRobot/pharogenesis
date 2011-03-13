performanceTestFileInScenario
	self prepareAllCaches.
	"decide the interesting sets"
	"set them up as such"
	"decide the classes and methods to be touched"
	self measure: 
		["touch the code as decided"
		"ask isAbsract of many classes"
		"ask requiredSelectors of a few"].
	self assert: realTime < 1000

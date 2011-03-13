testStartUpList
	"This test documents issue http://code.google.com/p/pharo/issues/detail?id=838"
	
	self assert: [ ((SystemDictionary classPool at: 'StartUpList') indexOf: #OSPlatform) < ((SystemDictionary classPool at: 'StartUpList') indexOf: #InputEventSensor) ]
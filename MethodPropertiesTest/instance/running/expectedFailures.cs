expectedFailures
	"The new closure compiler does not use MethodProperties.  These tests end up performing
	their assertions on AdditionalMethodState."
	
	^#(testAt testAtIfAbsent testIncludesKey testRemoveKey testRemoveKeyifAbsent)
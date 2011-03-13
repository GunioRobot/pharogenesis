flattenOnStream: aStream
" seems to not be the best solution to do that. 
  Imagine if the class Stream should have a method #writeSomething for each object existing in Pharo.
  Objects themeself have the information on how to be print . Not the stream. "
	^aStream writeDictionary:self.
test
	"self new test"
	
	|pa|
	pa := MCPackage named: 'FlexibleVocabularies'.
	pa workingCopy repositoryGroup addRepository: self repository.
	
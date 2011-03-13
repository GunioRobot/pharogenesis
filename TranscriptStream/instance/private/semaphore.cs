semaphore
	^AccessSema ifNil:[AccessSema := Semaphore forMutualExclusion]
signalExternalSemaphores
	"Signal all requested semaphores"
	| xArray xSize index sema |
	semaphoresUseBufferA _ semaphoresUseBufferA not.
	xArray _ self splObj: ExternalObjectsArray.
	xSize _ self stSizeOf: xArray.
	semaphoresUseBufferA
		ifTrue: ["use opposite buffer during read"
			1 to: semaphoresToSignalCountB do: [:i | 
					index _ semaphoresToSignalB at: i.
					index <= xSize
						ifTrue: [sema _ self fetchPointer: index - 1 ofObject: xArray.
							"Note: semaphore indices are 1-based"
							(self fetchClassOf: sema) = (self splObj: ClassSemaphore)
								ifTrue: [self synchronousSignal: sema]]].
			semaphoresToSignalCountB _ 0]
		ifFalse: [1 to: semaphoresToSignalCountA do: [:i | 
					index _ semaphoresToSignalA at: i.
					index <= xSize
						ifTrue: [sema _ self fetchPointer: index - 1 ofObject: xArray.
							"Note: semaphore indices are 1-based"
							(self fetchClassOf: sema) = (self splObj: ClassSemaphore)
								ifTrue: [self synchronousSignal: sema]]].
			semaphoresToSignalCountA _ 0]
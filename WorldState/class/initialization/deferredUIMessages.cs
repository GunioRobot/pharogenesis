deferredUIMessages

	^DeferredUIMessages ifNil: [DeferredUIMessages := SharedQueue new].

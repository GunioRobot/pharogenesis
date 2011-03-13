deferredUIMessages

	^DeferredUIMessages ifNil: [DeferredUIMessages _ SharedQueue new].

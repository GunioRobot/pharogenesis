asCompiledApplescriptWith: anApplescriptInstance

	| anAEDesc |
	anAEDesc _ self asAEDescWith: anApplescriptInstance.
	anAEDesc ifNil: [^nil].
	^anAEDesc asCompiledApplescriptThenDispose	
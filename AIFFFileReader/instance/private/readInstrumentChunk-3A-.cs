readInstrumentChunk: chunkSize

	| midiKey detune lowNote highNote lowVelocity highVelocity
	  sustainMode sustainStartID sustainEndID
	  releaseMode releaseStartID releaseEndID |

	midiKey _ in next.
	detune _ in next.
	lowNote _ in next.
	highNote _ in next.
	lowVelocity _ in next.
	highVelocity _ in next.
	gain _ in nextNumber: 2.
	sustainMode _ in nextNumber: 2.
	sustainStartID _ in nextNumber: 2.
	sustainEndID _ in nextNumber: 2.
	releaseMode _ in nextNumber: 2.
	releaseStartID _ in nextNumber: 2.
	releaseEndID _ in nextNumber: 2.
	isLooped _ sustainMode = 1.
	(isLooped and: [markers notNil]) ifTrue: [
		((markers first last > frameCount) or:
		 [markers last last > frameCount]) ifTrue: [
			"bad loop data; some sample CD files claim to be looped but aren't"
			isLooped _ false]].
	pitch _ self pitchForKey: midiKey.

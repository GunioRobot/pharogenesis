asBufferedCanvas

	| bufferedCanvas |

	bufferedCanvas _ BufferedCanvas new.
	connection cachingEnabled: false.
	bufferedCanvas
		connection: connection
		clipRect: NebraskaServer extremelyBigRectangle
		transform: MorphicTransform identity
		remoteCanvas: self.
	^bufferedCanvas
asQuaternion
	"Convert the matrix to a quaternion"

	| x y z a a2 x2 y2 a4 |

	a2 _ 0.25 * (1.0 + (self a11) + (self a22) + (self a33)).

	(a2 > 0) ifTrue: [
						a _ a2 sqrt.
						a4 _ 4.0 * a.
						x _ ((self a32) - (self a23)) / a4.
						y _ ((self a13) - (self a31)) / a4.
						z _ ((self a21) - (self a12)) / a4.
					]
			ifFalse: [
						a _ 0.
						x2 _ -0.5 * ((self a22) + (self a33)).
						(x2 > 0) ifTrue: [
											x _ x2 sqrt.
											x2 _ 2 * x.
											y _ (self a21) / x2.
											z _ (self a31) / x2.
										]
								ifFalse: [
											x _ 0.
											y2 _ 0.5 * (1.0 - (self a33)).
											(y2 > 0) ifTrue: [
																y _ y2 sqrt.
																y2 _ 2 * y.
																z _ (self a32) / y2.
															]
													ifFalse: [
																y _ 0.0.
																z _ 1.0.
															]
										]
					].

	^ (B3DRotation a: a b: x c: y d: z).

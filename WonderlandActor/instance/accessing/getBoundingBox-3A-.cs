getBoundingBox: reference
	"Returns the actor's bounding box"

	| RUF LDB min max cMatrix tMatrix tVector meshBBox |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyReferenceFrame: reference ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the bounding box of ' , myName , ' relative to ', (reference asString) , ' because ', msg.
			^ nil ].

	meshBBox _ self getBoundingBox.
	LDB _ meshBBox origin.
	RUF _ meshBBox corner.

	cMatrix _ (reference getMatrixToRoot) composeWith: (self getMatrixFromRoot).
	tMatrix _ B3DMatrix4x4 identity.

	tMatrix _ cMatrix composeWith: (tMatrix translation: RUF).
	min _ tMatrix translation.
	max _ tMatrix translation.
				
	tMatrix setIdentity.
	tVector _ (cMatrix composeWith: (tMatrix translation: LDB)) translation.	
	min _ min min: tVector.
	max _ max max: tVector.

	"Right up behind"
	tVector _ B3DVector3 x: (RUF x) y: (RUF y) z: (LDB z).
	tMatrix setIdentity.
	tVector _ (cMatrix composeWith: (tMatrix translation: tVector)) translation.	
	min _ min min: tVector.
	max _ max max: tVector.
	
	"Left up behind"
	tVector _ B3DVector3 x: (LDB x) y: (RUF y) z: (LDB z).
	tMatrix setIdentity.
	tVector _ (cMatrix composeWith: (tMatrix translation: tVector)) translation.	
	min _ min min: tVector.
	max _ max max: tVector.

	"Left up front"
	tVector _ B3DVector3 x: (LDB x) y: (RUF y) z: (RUF z).
	tMatrix setIdentity.
	tVector _ (cMatrix composeWith: (tMatrix translation: tVector)) translation.	
	min _ min min: tVector.
	max _ max max: tVector.

	"Right down behind"
	tVector _ B3DVector3 x: (RUF x) y: (LDB y) z: (LDB z).
	tMatrix setIdentity.
	tVector _ (cMatrix composeWith: (tMatrix translation: tVector)) translation.	
	min _ min min: tVector.
	max _ max max: tVector.

	"Right down front"
	tVector _ B3DVector3 x: (RUF x) y: (LDB y) z: (RUF z).
	tMatrix setIdentity.
	tVector _ (cMatrix composeWith: (tMatrix translation: tVector)) translation.	
	min _ min min: tVector.
	max _ max max: tVector.

	"Left down front"
	tVector _ B3DVector3 x: (LDB x) y: (LDB y) z: (RUF z).
	tMatrix setIdentity.
	tVector _ (cMatrix composeWith: (tMatrix translation: tVector)) translation.	
	min _ min min: tVector.
	max _ max max: tVector.

	^ Rectangle origin: min corner: max.

correctlyRotateDirectionArrow: aHandle forDegrees: degrees
	aHandle image: ((ScriptingSystem formAtKey: #Direction) rotateBy: degrees)

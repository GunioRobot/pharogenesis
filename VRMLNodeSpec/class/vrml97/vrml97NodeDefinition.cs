vrml97NodeDefinition
	"Node definitions from the VRML97 spec - HACKED in Script node!"
^'Anchor { 
  eventIn      MFNode   addChildren
  eventIn      MFNode   removeChildren
  exposedField MFNode   children        []
  exposedField SFString description     "" 
  exposedField MFString parameter       []
  exposedField MFString url             []
  field        SFVec3f  bboxCenter      0 0 0     # (-,)
  field        SFVec3f  bboxSize        -1 -1 -1  # (0,) or -1,-1,-1
}
Appearance { 
  exposedField SFNode material          NULL
  exposedField SFNode texture           NULL
  exposedField SFNode textureTransform  NULL
}
AudioClip { 
  exposedField   SFString description      ""
  exposedField   SFBool   loop             FALSE
  exposedField   SFFloat  pitch            1.0        # (0,)
  exposedField   SFTime   startTime        0          # (-,)
  exposedField   SFTime   stopTime         0          # (-,)
  exposedField   MFString url              []
  eventOut       SFTime   duration_changed
  eventOut       SFBool   isActive
}
Background { 
  eventIn      SFBool   set_bind
  exposedField MFFloat  groundAngle  []         # [0,/2]
  exposedField MFColor  groundColor  []         # [0,1]
  exposedField MFString backUrl      []
  exposedField MFString bottomUrl    []
  exposedField MFString frontUrl     []
  exposedField MFString leftUrl      []
  exposedField MFString rightUrl     []
  exposedField MFString topUrl       []
  exposedField MFFloat  skyAngle     []         # [0,]
  exposedField MFColor  skyColor     0 0 0      # [0,1]
  eventOut     SFBool   isBound
}
Billboard { 
  eventIn      MFNode   addChildren
  eventIn      MFNode   removeChildren
  exposedField SFVec3f  axisOfRotation 0 1 0     #	(-,)
  exposedField MFNode   children       []
  field        SFVec3f  bboxCenter     0 0 0     #	(-,)
  field        SFVec3f  bboxSize       -1 -1 -1  #	(0,) or -1,-1,-1
}
Box { 
  field    SFVec3f size  2 2 2        #	(0,	)
}
Collision { 
  eventIn      MFNode   addChildren
  eventIn      MFNode   removeChildren
  exposedField MFNode   children        []
  exposedField SFBool   collide         TRUE
  field        SFVec3f  bboxCenter      0 0 0      # (-,)
  field        SFVec3f  bboxSize        -1 -1 -1   # (0,) or -1,-1,-1
  field        SFNode   proxy           NULL
  eventOut     SFTime   collideTime
}
Color { 
  exposedField MFColor color  []         # [0,1]
}
ColorInterpolator { 
  eventIn      SFFloat set_fraction        # (-,)
  exposedField MFFloat key           []    # (-,)
  exposedField MFColor keyValue      []    # [0,1]
  eventOut     SFColor value_changed
}
Cone { 
  field     SFFloat   bottomRadius 1        # (0,)
  field     SFFloat   height       2        # (0,)
  field     SFBool    side         TRUE
  field     SFBool    bottom       TRUE
}
Coordinate { 
  exposedField MFVec3f point  []      # (-,)
}
CoordinateInterpolator { 
  eventIn      SFFloat set_fraction        # (-,)
  exposedField MFFloat key           []    # (-,)
  exposedField MFVec3f keyValue      []    # (-,)
  eventOut     MFVec3f value_changed
}
Cylinder { 
  field    SFBool    bottom  TRUE
  field    SFFloat   height  2         # (0,)
  field    SFFloat   radius  1         # (0,)
  field    SFBool    side    TRUE
  field    SFBool    top     TRUE
}
CylinderSensor { 
  exposedField SFBool     autoOffset TRUE
  exposedField SFFloat    diskAngle  0.262       # (0,/2)
  exposedField SFBool     enabled    TRUE
  exposedField SFFloat    maxAngle   -1          # [-2,2]
  exposedField SFFloat    minAngle   0           # [-2,2]
  exposedField SFFloat    offset     0           # (-,)
  eventOut     SFBool     isActive
  eventOut     SFRotation rotation_changed
  eventOut     SFVec3f    trackPoint_changed
}
DirectionalLight { 
  exposedField SFFloat ambientIntensity  0        # [0,1]
  exposedField SFColor color             1 1 1    # [0,1]
  exposedField SFVec3f direction         0 0 -1   # (-,)
  exposedField SFFloat intensity         1        # [0,1]
  exposedField SFBool  on                TRUE 
}
ElevationGrid { 
  eventIn      MFFloat  set_height
  exposedField SFNode   color             NULL
  exposedField SFNode   normal            NULL
  exposedField SFNode   texCoord          NULL
  field        MFFloat  height            []      # (-,)
  field        SFBool   ccw               TRUE
  field        SFBool   colorPerVertex    TRUE
  field        SFFloat  creaseAngle       0       # [0,]
  field        SFBool   normalPerVertex   TRUE
  field        SFBool   solid             TRUE
  field        SFInt32  xDimension        0       # [0,)
  field        SFFloat  xSpacing          1.0     # (0,)
  field        SFInt32  zDimension        0       # [0,)
  field        SFFloat  zSpacing          1.0     # (0,)
}
Extrusion { 
  eventIn MFVec2f    set_crossSection
  eventIn MFRotation set_orientation
  eventIn MFVec2f    set_scale
  eventIn MFVec3f    set_spine
  field   SFBool     beginCap         TRUE
  field   SFBool     ccw              TRUE
  field   SFBool     convex           TRUE
  field   SFFloat    creaseAngle      0                # [0,)
  field   MFVec2f    crossSection     [ 1 1, 1 -1, -1 -1,
                                       -1 1, 1  1 ]    # (-,)
  field   SFBool     endCap           TRUE
  field   MFRotation orientation      0 0 1 0          # [-1,1],(-,)
  field   MFVec2f    scale            1 1              # (0,)
  field   SFBool     solid            TRUE
  field   MFVec3f    spine            [ 0 0 0, 0 1 0 ] # (-,)
}
Fog { 
  exposedField SFColor  color            1 1 1      # [0,1]
  exposedField SFString fogType          "LINEAR"
  exposedField SFFloat  visibilityRange  0          # [0,)
  eventIn      SFBool   set_bind
  eventOut     SFBool   isBound
}
FontStyle { 
  field MFString family       "SERIF"
  field SFBool   horizontal   TRUE
  field MFString justify      "BEGIN"
  field SFString language     ""
  field SFBool   leftToRight  TRUE
  field SFFloat  size         1.0          # (0,)
  field SFFloat  spacing      1.0          # [0,)
  field SFString style        "PLAIN"
  field SFBool   topToBottom  TRUE
}
Group { 
  eventIn      MFNode  addChildren
  eventIn      MFNode  removeChildren
  exposedField MFNode  children      []
  field        SFVec3f bboxCenter    0 0 0     #	(-,)
  field        SFVec3f bboxSize      -1 -1 -1  #	(0,)	or	-1,-1,-1
}
ImageTexture { 
  exposedField MFString url     []
  field        SFBool   repeatS TRUE
  field        SFBool   repeatT TRUE
}
IndexedFaceSet { 
  eventIn       MFInt32 set_colorIndex
  eventIn       MFInt32 set_coordIndex
  eventIn       MFInt32 set_normalIndex
  eventIn       MFInt32 set_texCoordIndex
  exposedField  SFNode  color             NULL
  exposedField  SFNode  coord             NULL
  exposedField  SFNode  normal            NULL
  exposedField  SFNode  texCoord          NULL
  field         SFBool  ccw               TRUE
  field         MFInt32 colorIndex        []        # [-1,)
  field         SFBool  colorPerVertex    TRUE
  field         SFBool  convex            TRUE
  field         MFInt32 coordIndex        []        # [-1,)
  field         SFFloat creaseAngle       0         # [0,)
  field         MFInt32 normalIndex       []        # [-1,)
  field         SFBool  normalPerVertex   TRUE
  field         SFBool  solid             TRUE
  field         MFInt32 texCoordIndex     []        # [-1,)
}
IndexedLineSet { 
  eventIn       MFInt32 set_colorIndex
  eventIn       MFInt32 set_coordIndex
  exposedField  SFNode  color             NULL
  exposedField  SFNode  coord             NULL
  field         MFInt32 colorIndex        []     # [-1,)
  field         SFBool  colorPerVertex    TRUE
  field         MFInt32 coordIndex        []     # [-1,)
}
Inline { 
  exposedField MFString url        []
  field        SFVec3f  bboxCenter 0 0 0     #	(-,)
  field        SFVec3f  bboxSize   -1 -1 -1  #	(0,)	or	-1,-1,-1
}
LOD { 
  exposedField MFNode  level    [] 
  field        SFVec3f center   0 0 0    #	(-,)
  field        MFFloat range    []       #	(0,)
}
Material { 
  exposedField SFFloat ambientIntensity  0.2         #	[0,1]
  exposedField SFColor diffuseColor      0.8 0.8 0.8 #	[0,1]
  exposedField SFColor emissiveColor     0 0 0       #	[0,1]
  exposedField SFFloat shininess         0.2         #	[0,1]
  exposedField SFColor specularColor     0 0 0       #	[0,1]
  exposedField SFFloat transparency      0           #	[0,1]
}
MovieTexture { 
  exposedField SFBool   loop             FALSE
  exposedField SFFloat  speed            1.0      #	(-,)
  exposedField SFTime   startTime        0        #	(-,)
  exposedField SFTime   stopTime         0        #	(-,)
  exposedField MFString url              []
  field        SFBool   repeatS          TRUE
  field        SFBool   repeatT          TRUE
  eventOut     SFTime   duration_changed
  eventOut     SFBool   isActive
}
NavigationInfo { 
  eventIn      SFBool   set_bind
  exposedField MFFloat  avatarSize      [0.25, 1.6, 0.75] #	[0,)
  exposedField SFBool   headlight       TRUE
  exposedField SFFloat  speed           1.0               #	[0,)
  exposedField MFString type            ["WALK", "ANY"]
  exposedField SFFloat  visibilityLimit 0.0               #	[0,)
  eventOut     SFBool   isBound
}
Normal { 
  exposedField MFVec3f vector  []   #	(-,)
}
NormalInterpolator { 
  eventIn      SFFloat set_fraction       #	(-,)
  exposedField MFFloat key           []   #	(-,)
  exposedField MFVec3f keyValue      []   #	(-,)
  eventOut     MFVec3f value_changed
}
OrientationInterpolator { 
  eventIn      SFFloat    set_fraction      #	(-,)
  exposedField MFFloat    key           []  #	(-,)
  exposedField MFRotation keyValue      []  # [-1,1],(-,)
  eventOut     SFRotation value_changed
}
PixelTexture { 
  exposedField SFImage  image      0 0 0    # see 5.5, SFImage
  field        SFBool   repeatS    TRUE
  field        SFBool   repeatT    TRUE
}
PlaneSensor { 
  exposedField SFBool  autoOffset          TRUE
  exposedField SFBool  enabled             TRUE
  exposedField SFVec2f maxPosition         -1 -1     # (-,)
  exposedField SFVec2f minPosition         0 0       # (-,)
  exposedField SFVec3f offset              0 0 0     # (-,)
  eventOut     SFBool  isActive
  eventOut     SFVec3f trackPoint_changed
  eventOut     SFVec3f translation_changed
}
PointLight { 
  exposedField SFFloat ambientIntensity  0       # [0,1]
  exposedField SFVec3f attenuation       1 0 0   # [0,)
  exposedField SFColor color             1 1 1   # [0,1]
  exposedField SFFloat intensity         1       # [0,1]
  exposedField SFVec3f location          0 0 0   # (-,)
  exposedField SFBool  on                TRUE 
  exposedField SFFloat radius            100     # [0,)
}
PointSet { 
  exposedField  SFNode  color      NULL
  exposedField  SFNode  coord      NULL
}
PositionInterpolator { 
  eventIn      SFFloat set_fraction        # (-,)
  exposedField MFFloat key           []    # (-,)
  exposedField MFVec3f keyValue      []    # (-,)
  eventOut     SFVec3f value_changed
}
ProximitySensor { 
  exposedField SFVec3f    center      0 0 0    # (-,)
  exposedField SFVec3f    size        0 0 0    # [0,)
  exposedField SFBool     enabled     TRUE
  eventOut     SFBool     isActive
  eventOut     SFVec3f    position_changed
  eventOut     SFRotation orientation_changed
  eventOut     SFTime     enterTime
  eventOut     SFTime     exitTime
}
ScalarInterpolator { 
  eventIn      SFFloat set_fraction         # (-,)
  exposedField MFFloat key           []     # (-,)
  exposedField MFFloat keyValue      []     # (-,)
  eventOut     SFFloat value_changed
}
Script { 
  exposedField MFString url           [] 
  field        SFBool   directOutput  FALSE
  field        SFBool   mustEvaluate  FALSE
  # And any number of:
	#eventIn      eventType eventName
	#field        fieldType fieldName initialValue
	#eventOut     eventType eventName
	# AR note: This has been hacked !
	dummy		eventType	eventIn
	dummy		eventType	eventOut
	dummy 		fieldType	field
}
Shape { 

  exposedField SFNode appearance NULL
  exposedField SFNode geometry   NULL
}
Sound { 
  exposedField SFVec3f  direction     0 0 1   # (-,)
  exposedField SFFloat  intensity     1       # [0,1]
  exposedField SFVec3f  location      0 0 0   # (-,)
  exposedField SFFloat  maxBack       10      # [0,)
  exposedField SFFloat  maxFront      10      # [0,)
  exposedField SFFloat  minBack       1       # [0,)
  exposedField SFFloat  minFront      1       # [0,)
  exposedField SFFloat  priority      0       # [0,1]
  exposedField SFNode   source        NULL
  field        SFBool   spatialize    TRUE
}
Sphere { 
  field SFFloat radius  1    # (0,)
}
SphereSensor { 
  exposedField SFBool     autoOffset        TRUE
  exposedField SFBool     enabled           TRUE
  exposedField SFRotation offset            0 1 0 0  # [-1,1],(-,)
  eventOut     SFBool     isActive
  eventOut     SFRotation rotation_changed
  eventOut     SFVec3f    trackPoint_changed
}
SpotLight { 
  exposedField SFFloat ambientIntensity  0         # [0,1]
  exposedField SFVec3f attenuation       1 0 0     # [0,)
  exposedField SFFloat beamWidth         1.570796  # (0,/2]
  exposedField SFColor color             1 1 1     # [0,1]
  exposedField SFFloat cutOffAngle       0.785398  # (0,/2]
  exposedField SFVec3f direction         0 0 -1    # (-,)
  exposedField SFFloat intensity         1         # [0,1]
  exposedField SFVec3f location          0 0 0     # (-,)
  exposedField SFBool  on                TRUE
  exposedField SFFloat radius            100       # [0,)
}
Switch { 
  exposedField    MFNode  choice      []
  exposedField    SFInt32 whichChoice -1    # [-1,)
}
Text { 
  exposedField  MFString string    []
  exposedField  SFNode   fontStyle NULL
  exposedField  MFFloat  length    []      # [0,)
  exposedField  SFFloat  maxExtent 0.0     # [0,)
}
TextureCoordinate { 
  exposedField MFVec2f point  []      # (-,)
}
TextureTransform { 
  exposedField SFVec2f center      0 0     # (-,)
  exposedField SFFloat rotation    0       # (-,)
  exposedField SFVec2f scale       1 1     # (-,)
  exposedField SFVec2f translation 0 0     # (-,)
}
TimeSensor { 
  exposedField SFTime   cycleInterval 1       # (0,)
  exposedField SFBool   enabled       TRUE
  exposedField SFBool   loop          FALSE
  exposedField SFTime   startTime     0       # (-,)
  exposedField SFTime   stopTime      0       # (-,)
  eventOut     SFTime   cycleTime
  eventOut     SFFloat  fraction_changed      # [0,	1]
  eventOut     SFBool   isActive
  eventOut     SFTime   time
}
TouchSensor { 
  exposedField SFBool  enabled TRUE
  eventOut     SFVec3f hitNormal_changed
  eventOut     SFVec3f hitPoint_changed
  eventOut     SFVec2f hitTexCoord_changed
  eventOut     SFBool  isActive
  eventOut     SFBool  isOver
  eventOut     SFTime  touchTime
}
Transform { 
  eventIn      MFNode      addChildren
  eventIn      MFNode      removeChildren
  exposedField SFVec3f     center           0 0 0    #	(-,)
  exposedField MFNode      children         []
  exposedField SFRotation  rotation         0 0 1 0  # [-1,1],(-,)
  exposedField SFVec3f     scale            1 1 1    #	(0,)
  exposedField SFRotation  scaleOrientation 0 0 1 0  # [-1,1],(-,)
  exposedField SFVec3f     translation      0 0 0    #	(-,)
  field        SFVec3f     bboxCenter       0 0 0    #	(-,)
  field        SFVec3f     bboxSize         -1 -1 -1 #	(0,)	or	-1,-1,-1
} 
Viewpoint { 
  eventIn      SFBool     set_bind
  exposedField SFFloat    fieldOfView    0.785398  #	(0,)
  exposedField SFBool     jump           TRUE
  exposedField SFRotation orientation    0 0 1 0   # [-1,1],(-,)
  exposedField SFVec3f    position       0 0 10    #	(-,)
  field        SFString   description    ""
  eventOut     SFTime     bindTime
  eventOut     SFBool     isBound
}
VisibilitySensor { 
  exposedField SFVec3f center   0 0 0      #	(-,)
  exposedField SFBool  enabled  TRUE
  exposedField SFVec3f size     0 0 0      #	[0,)
  eventOut     SFTime  enterTime
  eventOut     SFTime  exitTime
  eventOut     SFBool  isActive
}
WorldInfo { 
  field MFString info  []
  field SFString title ""
}
'
show7

    " B3DDemoSpheres new show7"

     | view |
  self createScene7.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene7;
     scene: scene.
  view clearColor: (Color gray: 0.5).
  view rotateX: 25.4.
  view beRotating; openInSystemWindow.
show6

    " B3DDemoSpheres new show6"

     | view |
  self createScene6.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene6;
     scene: scene.
  view clearColor: (Color gray: 0.5).
  view rotateX: 25.4.
  view beRotating; openInSystemWindow.
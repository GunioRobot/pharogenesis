show8

    " B3DDemoSpheres new show8"

     | view |

  self createScene8.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene8;
     scene: scene.
  view clearColor: (Color gray: 0.5).
  view rotateX: 25.4.
  view beRotating; openInSystemWindow.
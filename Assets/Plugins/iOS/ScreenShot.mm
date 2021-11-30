//
//  ScreeenShot.mm
//  Unity-iPhone
//
//  Created by Ando Keigo on 2012/12/08.
//
//
#import <Foundation/Foundation.h>
#import <AVFoundation/AVFoundation.h>
#import <Photos/Photos.h>

extern "C" void SaveToAlbum (const char* path)
{
    // アルバム名を取得する
    PHFetchOptions *fetchOptions = [[PHFetchOptions alloc] init];
    fetchOptions.predicate = [NSPredicate predicateWithFormat:@"title = %@", @"アルバム名"];
    PHFetchResult *fetchResult = [PHAssetCollection fetchAssetCollectionsWithType:PHAssetCollectionTypeAlbum subtype:PHAssetCollectionSubtypeAny options:fetchOptions];

    // ファイルパスをURLにする
    NSURL *url = [NSURL fileURLWithPath:[NSString stringWithUTF8String:path]];

    // 写真を保存する
    [[PHPhotoLibrary sharedPhotoLibrary] performChanges:^{
        PHAssetChangeRequest *assetChangeRequest;
        assetChangeRequest = [PHAssetChangeRequest creationRequestForAssetFromImageAtFileURL:url];
        PHAssetCollectionChangeRequest *assetCollectionChangeRequest = [PHAssetCollectionChangeRequest changeRequestForAssetCollection:fetchResult.firstObject];
        [assetCollectionChangeRequest addAssets:@[[assetChangeRequest placeholderForCreatedAsset]]];

      } completionHandler:^(BOOL success, NSError *error) {
      }];
}

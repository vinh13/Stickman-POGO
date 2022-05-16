//
//  GADNativeContentAd.h
//  Google Mobile Ads SDK
//
//  Copyright 2015 Google Inc. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

#import <GoogleMobileAds/GADAdLoaderDelegate.h>
#import <GoogleMobileAds/GADMediaView.h>
#import <GoogleMobileAds/GADNativeAd.h>
#import <GoogleMobileAds/GADNativeAdImage.h>
#import <GoogleMobileAds/GADVideoController.h>
#import <GoogleMobileAds/GoogleMobileAdsDefines.h>

GAD_ASSUME_NONNULL_BEGIN

#pragma mark - Native Content Ad Assets

/// Native content ad. To request this ad type, you need to pass kGADAdLoaderAdTypeNativeContent
/// (see GADAdLoaderAdTypes.h) to the |adTypes| parameter in GADAdLoader's initializer method. If
/// you request this ad type, your delegate must conform to the GADNativeContentAdRequestDelegate
/// protocol.
@interface GADNativeContentAd : GADNativeAd

#pragma mark - Must be displayed

/// Primary text headline.
@property(nonatomic, readonly, copy, GAD_NULLABLE) NSString *headline;
/// Secondary text.
@property(nonatomic, readonly, copy, GAD_NULLABLE) NSString *body;

#pragma mark - Recommended to display

/// Large images.
@property(nonatomic, readonly, copy, GAD_NULLABLE) NSArray *images;
/// Small logo image.
@property(nonatomic, readonly, strong, GAD_NULLABLE) GADNativeAdImage *logo;
/// Text that encourages user to take some action with the ad.
@property(nonatomic, readonly, copy, GAD_NULLABLE) NSString *callToAction;
/// Identifies the advertiser. For example, the advertiser’s name or visible URL.
@property(nonatomic, readonly, copy, GAD_NULLABLE) NSString *advertiser;
/// Video controller for controlling video playback in GADNativeContentAdView's mediaView. Returns
/// nil if the ad doesn't contain a video asset.
@property(nonatomic, strong, readonly, GAD_NULLABLE) GADVideoController *videoController;
@end

#pragma mark - Protocol and constants

/// The delegate of a GADAdLoader object implements this protocol to receive GADNativeContentAd ads.
@protocol GADNativeContentAdLoaderDelegate<GADAdLoaderDelegate>
/// Called when native content is received.
- (void)adLoader:(GADAdLoader *)adLoader
    didReceiveNativeContentAd:(GADNativeContentAd *)nativeContentAd;
@end

#pragma mark - Native Content Ad View

/// Base class for content ad views. Your content ad view must be a subclass of this class and must
/// call superclass methods for all overriden methods.
@interface GADNativeContentAdView : UIView

/// This property must point to the native content ad object rendered by this ad view.
@property(nonatomic, strong, GAD_NULLABLE) GADNativeContentAd *nativeContentAd;

/// Weak reference to your ad view's headline asset view.
@property(nonatomic, weak, GAD_NULLABLE) IBOutlet UIView *headlineView;
/// Weak reference to your ad view's body asset view.
@property(nonatomic, weak, GAD_NULLABLE) IBOutlet UIView *bodyView;
/// Weak reference to your ad view's image asset view.
@property(nonatomic, weak, GAD_NULLABLE) IBOutlet UIView *imageView;
/// Weak reference to your ad view's logo asset view.
@property(nonatomic, weak, GAD_NULLABLE) IBOutlet UIView *logoView;
/// Weak reference to your ad view's call to action asset view.
@property(nonatomic, weak, GAD_NULLABLE) IBOutlet UIView *callToActionView;
/// Weak reference to your ad view's advertiser asset view.
@property(nonatomic, weak, GAD_NULLABLE) IBOutlet UIView *advertiserView;
/// Weak reference to your ad view's media asset view.
@property(nonatomic, weak, GAD_NULLABLE) IBOutlet GADMediaView *mediaView;

@end

GAD_ASSUME_NONNULL_END